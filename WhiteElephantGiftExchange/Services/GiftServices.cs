using WhiteElephantGiftExchange.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WhiteElephantGiftExchange.Services
{
    public class GiftServices
    {
        const string connectionString = @"Server=localhost\SQLEXPRESS;Database=GiftExchangeData;Trusted_Connection=True;";

        public List<Gifts> GetAllGifts()
        {
            var rv = new List<Gifts>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM GiftExchangeTable";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Gifts(reader));
                }
                connection.Close();
            }
            return rv;
        }


        public void AddGift(Gifts gift)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var newgift = @"INSERT INTO GiftExchangeTable (Contents, GiftHint, WrappingPaperColor, Height, Width, Depth, Weight, IsOpened)" +
                "Values (@Contents, @GiftHint, @WrappingPaperColor, @Height, @Width, @Depth, @Weight, @IsOpened)";

                var sqlCommand = new SqlCommand(newgift, connection);

                sqlCommand.Parameters.AddWithValue("@Contents", gift.Contents);
                sqlCommand.Parameters.AddWithValue("@GiftHint", gift.GiftHint);
                sqlCommand.Parameters.AddWithValue("@WrappingPaperColor", gift.WrappingPaperColor);
                sqlCommand.Parameters.AddWithValue("@Height", gift.Height);
                sqlCommand.Parameters.AddWithValue("@Width", gift.Width);
                sqlCommand.Parameters.AddWithValue("@Depth", gift.Depth);
                sqlCommand.Parameters.AddWithValue("@Weight", gift.Weight);
                sqlCommand.Parameters.AddWithValue("@IsOpened", gift.IsOpened);


                connection.Open();
                sqlCommand.ExecuteNonQuery(); 
                connection.Close();

            
            }
          

        }

        public void UpdateGift(Gifts revisedGift)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                

                var updateGift = @"UPDATE [dbo].[GiftExchangeTable] SET [Contents] = @Contents
                                                         ,[GiftHint] = @GiftHint
                                                         ,[WrappingPaperColor] = @WrappingPaperColor
                                                         ,[Height] = @Height
                                                         ,[Width] = @Width
                                                         ,[Depth] = @Depth
                                                         ,[Weight] = @Weight
                                                         ,[IsOpened] = @IsOpened
                                                          WHERE Id = @Id";

                var sqlCommand = new SqlCommand(updateGift, connection);

                sqlCommand.Parameters.AddWithValue("@Id", revisedGift.Id);
                sqlCommand.Parameters.AddWithValue("@Contents", revisedGift.Contents);
                sqlCommand.Parameters.AddWithValue("@GiftHint", revisedGift.GiftHint);
                sqlCommand.Parameters.AddWithValue("@WrappingPaperColor", revisedGift.WrappingPaperColor);
                sqlCommand.Parameters.AddWithValue("@Height", revisedGift.Height);
                sqlCommand.Parameters.AddWithValue("@Width", revisedGift.Width);
                sqlCommand.Parameters.AddWithValue("@Depth", revisedGift.Depth);
                sqlCommand.Parameters.AddWithValue("@Weight", revisedGift.Weight);             
               

                sqlCommand.Parameters.AddWithValue("@IsOpened", revisedGift.IsOpened);


                connection.Open();
                sqlCommand.ExecuteNonQuery(); //this is where its crashing
                connection.Close();


            }


        }
        public Gifts GetGift(int id)
        {
            var rv = new Gifts();
            using (var connection = new SqlConnection(connectionString))
            {

                var updatedGift = @"SELECT * FROM GiftExchangeTable WHERE @Id = Id;";

                var sqlCommand = new SqlCommand(updatedGift, connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
               
                connection.Open();
               var reader =  sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    rv = new Gifts(reader);
                }
                connection.Close();


            }
            return rv;


        }

    }

}