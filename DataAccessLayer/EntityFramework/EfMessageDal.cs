using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        private readonly IdentityContext _context;

        public EfMessageDal(IdentityContext context) : base(context)
        {
            _context = context;
        }

        public Message GetByIdWithSender(int id)
        {
            return _context.Messages
     .Include(m => m.AppUser) // Gönderici kullanıcı bilgilerini yüklemek için
     .Include(m => m.Category) // Mesajın kategorisini yüklemek için
     .FirstOrDefault(m => m.MessageId == id); // Mesaj ID'sine göre filtreleme
        }

        public List<Message> GetLastMessageByAppUserId(int UserId)
        {
            // Kullanıcının en son gönderdiği mesajı getirir.
            return _context.Messages
                .Include(m => m.AppUser) // Gönderici bilgilerini ekle
                .Include(m => m.Category) // Kategori bilgilerini ekle
                .Where(m => m.AppUserId == UserId) // Kullanıcı ID'sine göre filtrele
                .OrderByDescending(m => m.CreatedAt) // En yeni mesajlar önce gelir
                .Take(1) // Sadece en son mesajı getir
                .ToList();
        }

        public List<Message> GetMessagesByAppUserId(int UserId)
        {
            // Kullanıcıya ait tüm mesajları getirir.
            return _context.Messages
                .Include(m => m.AppUser) // Gönderici bilgilerini ekle
                .Include(m => m.Category) // Kategori bilgilerini ekle
                .Where(m => m.AppUserId == UserId) // Kullanıcı ID'sine göre filtrele
                .OrderByDescending(m => m.CreatedAt) // En yeni mesajlar önce gelir
                .ToList();
        }

        public List<Message> GetMessagesInbox(int userId)
        {
            return _context.Messages
                .Include(m => m.AppUser) // AppUser ile ilişki varsa yüklenir.
                .Include(m => m.Category) // Category ile ilişki varsa yüklenir.
                .Where(m => m.AppUserId == userId && !m.IsRead) // Belirtilen kullanıcı için okunmamış mesajlar.
                .OrderByDescending(m => m.CreatedAt) // En son oluşturulmuş mesajlar önce gelir.
                .ToList();
        }

        public List<Message> GetMessagesSendbox(string senderMail)
        {
            return _context.Messages
                .Include(m => m.AppUser) // AppUser ile ilişki varsa yüklenir.
                .Include(m => m.Category) // Category ile ilişki varsa yüklenir.
                .Where(m => m.SenderMail == senderMail) // Gönderen e-posta adresine göre filtreleme.
                .OrderByDescending(m => m.CreatedAt) // En son gönderilen mesajlar önce gelir.
                .ToList();
        }

        public List<Message> GetTrashMessages(string receiverMail)
        {
            return _context.Messages
                 .Where(m => m.ReceiverMail == receiverMail && m.IsRead)  // Alıcı mail adresine göre filtreleme
                 .OrderByDescending(m => m.CreatedAt)  // Mesajları tarihe göre sıralama
                 .ToList();  // Listeye dönüştürme
        }

        public List<Message> GetUnreadMessagesByAppUserId(int UserId)
        {
            // Kullanıcının okunmamış mesajlarını getirir.
            return _context.Messages
                .Include(m => m.AppUser) // Gönderici bilgilerini ekle
                .Include(m => m.Category) // Kategori bilgilerini ekle
                .Where(m => m.AppUserId == UserId && !m.IsRead) // Kullanıcı ID'sine göre filtrele ve okunmamış mesajları getir
                .OrderByDescending(m => m.CreatedAt) // En yeni mesajlar önce gelir
                .ToList();
        }

        public Message MessageDetails(int id)
            {
                return _context.Messages
                    .Include(m => m.AppUser)
                    .Include(m => m.Category)
                    .FirstOrDefault(m => m.MessageId == id);

            }
        }
    }


