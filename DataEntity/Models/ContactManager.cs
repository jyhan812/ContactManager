using System.Linq;
using DataEntity;

namespace DataEntity.Models
{
    public class ContactManager
    {
        public void AddContact(ContactModel contact)
        {

            using (ContactDBEntities db = new ContactDBEntities())
            {

                ContactView CT = new ContactView();
                CT.FirstName = contact.FirstName;
                CT.LastName = contact.LastName;
                CT.Phone = contact.Phone;
                CT.Email = contact.Email;
                CT.Street = contact.Street;
                CT.City = contact.City;
                CT.State = contact.State;
                CT.PostalCode = contact.PostalCode;

                db.ContactViews.Add(CT);
                db.SaveChanges();

            }
        }

        public void UpdateContact(ContactModel contact)
        {

            using (ContactDBEntities db = new ContactDBEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        ContactView CT = db.ContactViews.Find(contact.ContactID);
                        CT.FirstName = contact.FirstName;
                        CT.LastName = contact.LastName;
                        CT.Phone = contact.Phone;
                        CT.Email = contact.Email;
                        CT.Street = contact.Street;
                        CT.City = contact.City;
                        CT.State = contact.State;
                        CT.PostalCode = contact.PostalCode;

                        db.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        public void DeleteUser(int contactID)
        {
            using (ContactDBEntities db = new ContactDBEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        var CT = db.ContactViews.Where(o => o.ContactID == contactID);
                        if (CT.Any())
                        {
                            db.ContactViews.Remove(CT.FirstOrDefault());
                            db.SaveChanges();
                        }

                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}
