using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Model
{
    public class ContactsRepository
    {
        private List<ContactInfo> contacts = new List<ContactInfo>();

        public void AddContact(ContactInfo contact)
        {
            contact.Id = contacts.Count > 0 ? contacts.Max(c => c.Id) + 1 : 1; // Auto-increment ID
            contacts.Add(contact);
        }

        public ContactInfo GetContact(int id)
        {
            return contacts.FirstOrDefault(c => c.Id == id);
        }

        public List<ContactInfo> GetContacts()
        {
            return contacts;
        }

        public void UpdateContact(ContactInfo updatedContact)
        {
            var contact = GetContact(updatedContact.Id);
            if (contact != null)
            {
                contact.NameSurname = updatedContact.NameSurname;
                contact.PhoneNumber = updatedContact.PhoneNumber;
                contact.Email = updatedContact.Email;
            }
        }
    }

}
