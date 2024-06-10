using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
namespace HttpAssignment1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Run(async(HttpContext context) =>
            {
                StreamReader st = new StreamReader(context.Request.Body);
                string str =await st.ReadToEndAsync();
                Dictionary<string, string> keyValuePairs = QueryHelpers.ParseQuery(str)
                 
                .ToDictionary(x => x.Key, x => x.Value.ToString());


                if (!string.IsNullOrEmpty(keyValuePairs["n1"]))
                {
                    int num1 = Convert.ToInt32(keyValuePairs["n1"]);

                    if (!string.IsNullOrEmpty(keyValuePairs["n2"]))
                    {
                        int num2 = Convert.ToInt32(keyValuePairs["n2"]);
                        string op = keyValuePairs["n3"];

                        if(op=="add")
                        { 
                            string sum = (num1 + num2).ToString();
                            await context.Response.WriteAsync(sum);
                        }
                        else if(op=="sub")
                        {
                            string sub = (num1 - num2).ToString();
                            await context.Response.WriteAsync(sub);

                        }
                        else if (op == "div")
                        {
                            string div = (num1/num2).ToString();
                            await context.Response.WriteAsync(div);

                        }
                        else
                        {
                            string mul = (num1*num2).ToString();
                            await context.Response.WriteAsync(mul);
                        }


                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid second input:");
                    }
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid first input:");
                }

               

                
               
               
               



            });

            app.Run();
        }
    }
}
