using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManageProperty.Data;
using ManageProperty.Models;

namespace ManageProperty.Controllers
{
    public class MessagesController : Controller
    {
        private readonly EstateDbContext _context;

        public MessagesController(EstateDbContext context)
        {
            _context = context;
        }

        // GET: Messages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Messages.ToListAsync());
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        public async Task<IActionResult> DetailsTenants(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MessageId,SenderId,ReceiverId,Content,SentAt")] Message message)
        {
            if (ModelState.IsValid)
            {
                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Messages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MessageId,SenderId,ReceiverId,Content,SentAt")] Message message)
        {
            if (id != message.MessageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.MessageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }
        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ViewReceivedMessages));
        }

        public async Task<IActionResult> DeleteTenants(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("DeleteTenants")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedTenants(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ViewReceivedMessagesForTenants));
        }

        private bool MessageExists(int id)
        {
            return _context.Messages.Any(e => e.MessageId == id);
        }

        // Method for sending messages (For Tenants)
        [HttpGet]
        public IActionResult SendMessage()
        {
            var managers = _context.Managers.Select(m => new
            {
                ManagerId = m.ManagerId,
                ManagerName = m.FirstName + " " + m.LastName
            }).ToList();

            ViewBag.Managers = new SelectList(managers, "ManagerId", "ManagerName");

            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(int receiverId, string content)
        {
            var senderId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            if (senderId == 0)
            {
                ModelState.AddModelError("", "Sender ID not found in session.");
                var managers = _context.Managers
                    .Select(m => new
                    {
                        ManagerId = m.ManagerId,
                        ManagerName = m.FirstName + " " + m.LastName
                    })
                    .ToList();

                ViewBag.Managers = new SelectList(managers, "ManagerId", "ManagerName");

                ViewBag.Content = content;

                return View();
            }

            var message = new Message
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Content = content,
                SentAt = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                _context.Messages.Add(message);
                _context.SaveChanges();
                return RedirectToAction(nameof(ViewReceivedMessagesForTenants));
            }

            var managerList = _context.Managers
                .Select(m => new
                {
                    ManagerId = m.ManagerId,
                    ManagerName = m.FirstName + " " + m.LastName
                })
                .ToList();

            ViewBag.Managers = new SelectList(managerList, "ManagerId", "ManagerName");
            // Ensure the message content is retained
            ViewBag.Content = content;

            return View(message);
        }

        // Method for replying to messages (For Managers)
        [HttpGet]
        public IActionResult Reply(int originalMessageId)
        {
            var originalMsg = _context.Messages.Find(originalMessageId);
            if (originalMsg == null)
            {
                return NotFound("Original message not found.");
            }

            ViewBag.OriginalMessage = originalMsg;

            return View();
        }

        public IActionResult ReplyForTenants(int originalMessageId)
        {
            var originalMsg = _context.Messages.Find(originalMessageId);
            if (originalMsg == null)
            {
                return NotFound("Original message not found.");
            }

            ViewBag.OriginalMessage = originalMsg;

            return View();
        }

        [HttpPost]
        public IActionResult ReplyForTenants(int originalMessageId, string content)
        {
            var senderId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            if (senderId == 0)
            {
                ModelState.AddModelError("", "Sender ID not found in session.");
                var originalMsg = _context.Messages.Find(originalMessageId);
                ViewBag.OriginalMessage = originalMsg; // Ensure the original message is retained
                ViewBag.Content = content; // Ensure the reply content is retained
                return View();
            }

            var originalMsgToReply = _context.Messages.Find(originalMessageId);
            if (originalMsgToReply == null)
            {
                ModelState.AddModelError("", "Original message not found.");
                ViewBag.OriginalMessage = originalMsgToReply; // Ensure the original message is retained
                ViewBag.Content = content; // Ensure the reply content is retained
                return View();
            }

            var replyMessage = new Message
            {
                SenderId = senderId,
                ReceiverId = originalMsgToReply.SenderId,
                Content = content,
                SentAt = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                _context.Messages.Add(replyMessage);
                _context.SaveChanges();
                return RedirectToAction("ViewReceivedMessagesForTenants", "Messages");
            }

            ViewBag.OriginalMessage = originalMsgToReply; // Ensure the original message is retained
            ViewBag.Content = content; // Ensure the reply content is retained

            return View(replyMessage);
        }

        [HttpPost]
        public IActionResult Reply(int originalMessageId, string content)
        {
            var senderId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            if (senderId == 0)
            {
                ModelState.AddModelError("", "Sender ID not found in session.");
                var originalMsg = _context.Messages.Find(originalMessageId);
                ViewBag.OriginalMessage = originalMsg; // Ensure the original message is retained
                ViewBag.Content = content; // Ensure the reply content is retained
                return View();
            }

            var originalMsgToReply = _context.Messages.Find(originalMessageId);
            if (originalMsgToReply == null)
            {
                ModelState.AddModelError("", "Original message not found.");
                ViewBag.OriginalMessage = originalMsgToReply; // Ensure the original message is retained
                ViewBag.Content = content; // Ensure the reply content is retained
                return View();
            }

            var replyMessage = new Message
            {
                SenderId = senderId,
                ReceiverId = originalMsgToReply.SenderId,
                Content = content,
                SentAt = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                _context.Messages.Add(replyMessage);
                _context.SaveChanges();
                return RedirectToAction("ViewReceivedMessages", "Messages");
            }

            ViewBag.OriginalMessage = originalMsgToReply; // Ensure the original message is retained
            ViewBag.Content = content; // Ensure the reply content is retained

            return View(replyMessage);
        }


        // Method to view messages (For both Tenants and Managers)
        // Method to view sent messages
        public IActionResult ViewSentMessages()
        {
            var userId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            if (userId == 0)
            {
                return NotFound("User ID not found in session.");
            }

            var messages = from m in _context.Messages
                           join s in _context.Tenants on m.ReceiverId equals s.TenantId into receiverTenants
                           from rt in receiverTenants.DefaultIfEmpty()
                           join r in _context.Managers on m.ReceiverId equals r.ManagerId into receiverManagers
                           from rm in receiverManagers.DefaultIfEmpty()
                           where m.SenderId == userId
                           select new MessageDetailsModel
                           {
                               MessageId = m.MessageId,
                               ReceiverId = m.ReceiverId,
                               Content = m.Content,
                               SentAt = m.SentAt,
                               ReceiverName = rt.FirstName + " " + rt.LastName ?? rm.FirstName + " " + rm.LastName
                           };

            return View(messages.ToList());
        }
        // Method to view received messages
        public IActionResult ViewReceivedMessages()
        {
            var userId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            if (userId == 0)
            {
                return NotFound("User ID not found in session.");
            }

            var messages = from m in _context.Messages
                           join s in _context.Tenants on m.SenderId equals s.TenantId into senderTenants
                           from st in senderTenants.DefaultIfEmpty()
                           join sm in _context.Managers on m.SenderId equals sm.ManagerId into senderManagers
                           from sm in senderManagers.DefaultIfEmpty()
                           where m.ReceiverId == userId
                           select new MessageDetailsModel
                           {
                               MessageId = m.MessageId,
                               SenderId = m.SenderId,
                               Content = m.Content,
                               SentAt = m.SentAt,
                               SenderName = st.FirstName + " " + st.LastName ?? sm.FirstName + " " + sm.LastName
                           };

            return View(messages.ToList());
        }
        // Method to view received messages for tenants
        public IActionResult ViewReceivedMessagesForTenants()
        {
            var userId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            if (userId == 0)
            {
                return NotFound("User ID not found in session.");
            }

            var messages = from m in _context.Messages
                           join s in _context.Tenants on m.SenderId equals s.TenantId into senderTenants
                           from st in senderTenants.DefaultIfEmpty()
                           join sm in _context.Managers on m.SenderId equals sm.ManagerId into senderManagers
                           from sm in senderManagers.DefaultIfEmpty()
                           where m.ReceiverId == userId
                           select new MessageDetailsModel
                           {
                               MessageId = m.MessageId,
                               SenderId = m.SenderId,
                               Content = m.Content,
                               SentAt = m.SentAt,
                               // SenderName = st != null ? (st.FirstName + " " + st.LastName) : (sm != null ? (sm.FirstName + " " + sm.LastName) : "Unknown Sender")               
                               SenderName = ""
                           };
            var messageList = messages.ToList();

            foreach (var message in messageList)
            {
                var tenant = _context.Tenants.SingleOrDefault(t => t.TenantId == message.SenderId);
                var manager = _context.Managers.SingleOrDefault(m => m.ManagerId == message.SenderId);

                if (tenant != null)
                {
                    message.SenderName = $"{tenant.FirstName} {tenant.LastName}";
                }
                else if (manager != null)
                {
                    message.SenderName = $"{manager.FirstName} {manager.LastName}";
                }
                else
                {
                    message.SenderName = "Unknown Sender";
                }
            }

            return View(messageList);
        }
    }
}

