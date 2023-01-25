// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;

string input = "cxdnnyjw";
StringBuilder password = new StringBuilder(8);
string[] passwordArray = new string[8];
int found = 0;
int i = 0;
while (found < 8)
{
    string temp = input + i;
    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(temp);
    byte[] hashBytes = MD5.Create().ComputeHash(inputBytes);
    string hex = Convert.ToHexString(hashBytes);
    char[] chars = hex.ToCharArray();
    bool leadingZeros = true;
    for (int j = 0; j < 5; j++)
    {
        char c = chars[j];
        if (c != '0')
        {
            leadingZeros = false;
        }
    }
    if (leadingZeros)
    {
        if (char.IsDigit(chars[5]) && chars[5] - '0' < 8)
        {
           
            if (passwordArray[chars[5] - '0'] == null)
            {
                Console.WriteLine(hex);
                passwordArray[chars[5] - '0'] = hex.Substring(6, 1);
                found++;
            }
        }
    }
    i++;
}
foreach(string s in passwordArray)
{
    password.Append(s);
}
Console.WriteLine(password);
