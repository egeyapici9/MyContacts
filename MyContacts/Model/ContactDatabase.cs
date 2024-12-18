using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Model
{
    public class ContactDatabase
    {
        SQLiteAsyncConnection Database;

        private async Task Init()
        {
            if (Database is not null) return;
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<ContactInfo>();
        }

        public async Task<List<ContactInfo>> GetAllContactsAsync()
        {
            await Init();
            List<ContactInfo> contacts = await Database.Table<ContactInfo>().ToListAsync();
            return contacts;
        }

        public async Task InsertContact(ContactInfo contact)
        {
            await Init();
            await Database.InsertAsync(contact);
        }

        public async Task<ContactInfo> GetContactByIdAsync(int id)
        {
            await Init();
            ContactInfo contact = await Database.Table<ContactInfo>().Where(c => c.Id == id).FirstOrDefaultAsync();
            return contact;
        }

        public async Task DeleteContact(ContactInfo contact)
        {
            await Init();
            await Database.DeleteAsync(contact);
            await Init();
            await Database.DeleteAsync(contact);
        }

        public async Task UpdateContract(ContactInfo contact)
        {
            await Database.UpdateAsync(contact);
        }
    }
}