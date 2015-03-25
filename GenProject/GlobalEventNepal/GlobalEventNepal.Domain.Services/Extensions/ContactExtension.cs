using GlobalEventNepal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GlobalEventNepal.Domain.Services.Extensions
{
    public static class ContactExtension
    {
        /// <summary>
        /// Set Ids for this Contact and also give new Ids to all navigational properties for this contact
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="id"></param>
        /// <param name="integrisPatientId"></param>
        /// <param name="forceNewIds"></param>
        /// <param name="isTemplateContact"></param>
        /// <returns></returns>
        public static Contact SetIds(this Contact contact, Guid id)
        {
            contact.Id = id;
            
            if (contact.CreatedDate == default(DateTime))
            {
                contact.CreatedDate = DateTime.Now;
            }

            if (contact.Addresses != null)
            {
                Parallel.ForEach(contact.Addresses, address =>
                {
                    if (address == null) return;

                    if (address.Id == Guid.Empty)
                    {
                        address.Id = Guid.NewGuid();
                    }
                    address.ContactId = id;
                });

                contact.Addresses = contact.Addresses.OrderBy(address => address.Id).ToList();
            }

            if (contact.EmailAddresses != null)
            {
                Parallel.ForEach(contact.EmailAddresses, email =>
                {
                    if (email == null) return;

                    if (email.Id == Guid.Empty)
                    {
                        email.Id = Guid.NewGuid();
                    }
                    email.ContactId = id;
                });

                contact.EmailAddresses = contact.EmailAddresses.OrderBy(email => email.Id).ToList();
            }

            if (contact.Phones != null)
            {
                Parallel.ForEach(contact.Phones, phone =>
                {
                    if (phone == null) return;

                    if (phone.Id == Guid.Empty)
                    {
                        phone.Id = Guid.NewGuid();
                    }
                    phone.ContactId = id;
                });

                contact.Phones = contact.Phones.OrderBy(phone => phone.Id).ToList();
            }

            return contact;
        }

        public static Contact UpdateContact(this Contact baseContact,
        Contact contact, List<object> cleanupObjects)
        {
            if (baseContact == null || contact == null) return null;

            #region Singular Properties

            baseContact.FirstName = contact.FirstName;
            baseContact.LastName = contact.LastName;
            
            #endregion Singular Properties

            #region Addresses
            foreach (ContactAddress existingAddress in baseContact.Addresses)
            {
                ContactAddress alteredAddress =
                    contact.Addresses.FirstOrDefault(c => c.Id == existingAddress.Id);

                if (alteredAddress == null)
                {
                    //old value not in current values, delete it (at a later point)
                    cleanupObjects.Add(existingAddress);
                }
                else
                {
                    //Does exist, so update it
                    existingAddress.UpdateAddress(alteredAddress);
                }
            }

            //Add new coded values
            foreach (ContactAddress address in contact.Addresses)
            {
                if (baseContact.Addresses.All(c => c.Id != address.Id))
                {
                    baseContact.Addresses.Add(address);
                }
            }

            baseContact.Addresses = baseContact.Addresses.OrderBy(a => a.Id).ToList();
            #endregion Addresses

            #region Emails
            foreach (ContactEmail existingEmailAddress in baseContact.EmailAddresses)
            {
                ContactEmail alteredEmail =
                    contact.EmailAddresses.FirstOrDefault(c => c.Id == existingEmailAddress.Id);

                if (alteredEmail == null)
                {
                    //old value not in current values, delete it (at a later point)
                    cleanupObjects.Add(existingEmailAddress);
                }
                else
                {
                    //Does exist, so update it
                    existingEmailAddress.UpdateEmailAddress(alteredEmail);
                }
            }

            //Add new coded values
            foreach (ContactEmail email in contact.EmailAddresses)
            {
                if (baseContact.EmailAddresses.All(c => c.Id != email.Id))
                {
                    baseContact.EmailAddresses.Add(email);
                }
            }

            baseContact.EmailAddresses = baseContact.EmailAddresses.OrderBy(e => e.Id).ToList();
            #endregion Emails

            #region Phones
            foreach (ContactPhone existingPhones in baseContact.Phones)
            {
                ContactPhone alteredPhone =
                    contact.Phones.FirstOrDefault(c => c.Id == existingPhones.Id);

                if (alteredPhone == null)
                {
                    //old value not in current values, delete it (at a later point)
                    cleanupObjects.Add(existingPhones);
                }
                else
                {
                    //Does exist, so update it
                    existingPhones.UpdatePhone(alteredPhone);
                }
            }

            //Add new coded values
            foreach (ContactPhone phone in contact.Phones)
            {
                if (baseContact.Phones.All(c => c.Id != phone.Id))
                {
                    baseContact.Phones.Add(phone);
                }
            }

            baseContact.Phones = baseContact.Phones.OrderBy(p => p.Id).ToList();
            #endregion Phones

            return baseContact;
        }

        public static ContactAddress UpdateAddress(this ContactAddress baseAddress, ContactAddress updatedAddress)
        {
            baseAddress.Street1 = updatedAddress.Street1;
            baseAddress.Street2 = updatedAddress.Street2;
            baseAddress.Street3 = updatedAddress.Street3;
            baseAddress.City = updatedAddress.City;
            baseAddress.State = updatedAddress.State;
            baseAddress.Country = updatedAddress.Country;
            baseAddress.PostalCode = updatedAddress.PostalCode;

            return baseAddress;
        }

        public static ContactEmail UpdateEmailAddress(this ContactEmail baseEmail, ContactEmail updatedEmail)
        {
            baseEmail.Address = updatedEmail.Address;
            baseEmail.Description = updatedEmail.Description;
            baseEmail.IsPrimary = updatedEmail.IsPrimary;

            return baseEmail;
        }

        public static ContactPhone UpdatePhone(this ContactPhone basePhone, ContactPhone updatedPhone)
        {
            basePhone.Number = updatedPhone.Number;
            basePhone.Description = updatedPhone.Description;
            basePhone.IsPrimary = updatedPhone.IsPrimary;

            return basePhone;
        }
    }
}