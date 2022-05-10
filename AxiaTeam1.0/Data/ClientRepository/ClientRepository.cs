using AxiaTeam1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data.ClientRepository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _clientContext;

        public ClientRepository(DataContext clientContext)
        {
            _clientContext = clientContext;
        }
        public Models.Client Create(Client c)
        {
            _clientContext.Clients.Add(c);
            _clientContext.SaveChanges();
            return c;
        }

        public void Delete(int id)
        {
            var client = _clientContext.Clients.FirstOrDefault(c => c.Id == id);
            _clientContext.Clients.Remove(client);
            _clientContext.SaveChanges();
        }

        public Models.Client EditClient(Models.Client c)
        {
            var client = _clientContext.Clients.FirstOrDefault(c => c.Id ==c.Id);
            if (!(c.Name is null) && !(c.Name == client.Name))
                client.Name = c.Name;
            if (!(c.Description is null) && !(c.Description == client.Description))
                client.Description = c.Description;
            if (!(c.Website is null) && !(c.Website == client.Website))
                client.Website = c.Website;
            if (!String.IsNullOrEmpty(c.Phone.ToString()) && !(c.Phone == client.Phone))
                client.Phone = c.Phone;
            if (!(c.Fax is null) && !(c.Fax == client.Fax))
                client.Fax = c.Fax;
            if (!(c.Country is null) && !(c.Country == client.Country))
                client.Country = c.Country;
            if (!(c.State is null) && !(c.State == client.State))
                client.State = c.State;
            if (!(c.Adress is null) && !(c.Adress == client.Adress))
                client.Adress = c.Adress;


            _clientContext.SaveChanges();

            return client;
        }

        public List<Models.Client> getAll()
        {
            return _clientContext.Clients.ToList();
        }

        public Models.Client GetById(int id)
        {
            return _clientContext.Clients.FirstOrDefault(c => c.Id == id);
            
        }
    }
}
