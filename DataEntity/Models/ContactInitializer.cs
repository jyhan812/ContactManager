using System.Collections.Generic;

namespace DataEntity.Models
{
    public class ContactInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ContactContext>
    {
        protected override void Seed(ContactContext context)
        {
            var contacts = new List<ContactModel>
            {
            new ContactModel{FirstName="Eddy",LastName="Deab",Phone="516-111-2222", Email="Eddy@gmail.com", Street="111 abc street", City="Woodbury", State="NY", PostalCode="11797"},
            new ContactModel{FirstName="Joy",LastName="Han",Phone="516-222-3333", Email="Joy@gmail.com", Street="222 def street", City="Mellville", State="NY", PostalCode="11794"},
            new ContactModel{FirstName="Tracy",LastName="Bram",Phone="516-333-4444", Email="Tracy@gmail.com", Street="ghi abc street", City="Hicksville", State="NY", PostalCode="11801"},
            new ContactModel{FirstName="Joyce",LastName="Li",Phone="516-444-5555", Email="Joyce@gmail.com", Street="444 jkl street", City="Jericho", State="NY", PostalCode="11753"},
            new ContactModel{FirstName="Anthony",LastName="Norman",Phone="516-555-6666", Email="Anthony@gmail.com", Street="555 mno street", City="Huntington", State="NY", PostalCode="11721"},
            new ContactModel{FirstName="Peter",LastName="Justice",Phone="516-666-7777", Email="Peter@gmail.com", Street="666 pqr street", City="Plainview", State="NY", PostalCode="11803"},
            new ContactModel{FirstName="Joshua",LastName="Olive",Phone="516-777-8888", Email="Joshua@gmail.com", Street="777 stu street", City="Bethpage", State="NY", PostalCode="11714"},
            new ContactModel{FirstName="Ryan",LastName="Peggy",Phone="516-888-9999", Email="Ryan@gmail.com", Street="888 vwx street", City="Flushing", State="NY", PostalCode="11353"}
            };

            contacts.ForEach(s => context.Contact.Add(s));
            context.SaveChanges();

        }
    }
}
