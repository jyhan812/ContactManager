using DataEntity.Models;
using System.Linq;

namespace ContactManager.Helpers
{
    public class UpdateDisplayName
    {
        
        public void updateDisplayName()
        {
            using (var context = new ContactContext())
            {

                foreach (var ct in context.Contact.ToList())
                {
                    ct.DisplayName = ct.FirstName + ' ' + ct.LastName;
                }
                context.SaveChanges();

            }

        }
    }
}