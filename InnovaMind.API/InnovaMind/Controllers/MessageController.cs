using AutoMapper;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Resources;
using InnovaMind.API.Security.Authorization.Attributes;
using InnovaMind.API.Security.Domain.Models;
using InnovaMind.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace InnovaMind.API.InnovaMind.Controllers;

[Route("/api/v1/{userid}/[controller]")]
    
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;
    
    public MessageController(IMessageService messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IEnumerable<MessageResource>> GetAllMessagesAsync(int userid, int id)
    {
        var messages = await _messageService.GetMessagesAsync();
        var resources = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
        

        resources = resources.Where(x => (x.Emitter.Id == userid && x.Receiver.Id == id) || (x.Emitter.Id == id && x.Receiver.Id == userid)).OrderBy(x => x.Id).ToList();
        return resources;
    }


    [HttpGet("recruiters")]
    public async Task<IEnumerable<MessageResource>> GetLastMessageRecruiter(int userid)
    {
        var messages2 = await _messageService.GetLastMessageRecruiter(userid);
        var resources2 = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages2);

        return resources2;
    }

    [HttpGet("drivers")]
    public async Task<IEnumerable<MessageResource>> GetLastMessageDriver(int userid)
    {
        var messages3 = await _messageService.GetLastMessageDriver(userid);
        var resources3 = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages3);

        return resources3;
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddMessageAsync([FromBody] SaveMessageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var message = _mapper.Map<SaveMessageResource, Message>(resource);

        var result = await _messageService.AddMessageAsync(message);

        if (!result.Success)
            return BadRequest(result.Message);

        var messageResource = _mapper.Map<Message, MessageResource>(result.Resource);

        return Ok(messageResource);
    }
}

