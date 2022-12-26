using ChatApi.Models;
using System.Collections.Generic;

namespace ChatApi.Data
{
    public class DataSource
    {
        public static List<Client> Clients { get; } = new List<Client>();
    }
}
