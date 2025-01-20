using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class RandomViewModelMovie
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }

    }
}