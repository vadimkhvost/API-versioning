﻿namespace Microsoft.Web.Http.Simulators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        [Key]
        public int Id { get; set; }
    }
}