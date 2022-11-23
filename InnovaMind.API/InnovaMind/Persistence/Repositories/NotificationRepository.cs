﻿using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.Shared.Persistence.Contexts;
using InnovaMind.API.Shared.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

namespace InnovaMind.API.InnovaMind.Persistence.Repositories
{

    public class NotificationRepository : BaseRepository, INotificationRepository
    {
        public NotificationRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Notification>> GetNotificationsAsync()
        {
            return await _context.Notifications.Include(p => p.Emitter).Include(q => q.Receiver).ToListAsync();
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
        }

        public async Task<Notification> FindNotificationByIdAsync(int id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public async Task<IEnumerable<Notification>> GetLastNotificationRecruiter(int id)
        {
            var lastNotification = await _context.Notifications
                .FromSqlInterpolated(
                    $"SELECT * FROM notifications n WHERE id IN (SELECT MAX(id) FROM notifications WHERE emitter_id = {id} GROUP BY receiver_id)")
                .Include(p => p.Emitter).ToListAsync();
            return lastNotification;
        }

        public async Task<IEnumerable<Notification>> GetLastNotificationDriver(int id)
        {
            var lastNotification = await _context.Notifications
                .FromSqlInterpolated(
                    $"SELECT * FROM notifications n WHERE id IN (SELECT MAX(id) FROM notifications WHERE receiver_id = {id} GROUP BY emitter_id)")
                .Include(p => p.Emitter).ToListAsync();
            return lastNotification;
        }
        
        public void Remove(Notification notification)
        {
            _context.Notifications.Remove(notification);
        }

    }
}