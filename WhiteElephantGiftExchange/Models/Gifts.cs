using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WhiteElephantGiftExchange.Models
{
    public class Gifts
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public string GiftHint { get; set; }
        public string WrappingPaperColor { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public bool? IsOpened { get; set; } = false;

        public Gifts() { }
        public Gifts(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Contents = reader["Contents"]?.ToString();
            this.GiftHint = reader["GiftHint"]?.ToString();
            this.WrappingPaperColor = reader["WrappingPaperColor"]?.ToString();
            this.Height = (double)reader["Height"];
            this.Width = (double)reader["Width"];
            this.Depth = (double)reader["Depth"];
            this.Weight = (double)reader["Weight"];
            this.IsOpened = (bool?)reader["IsOpened"];
        }
    }

}