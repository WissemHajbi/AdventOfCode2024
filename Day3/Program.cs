using System.Text.RegularExpressions;

StreamReader st = new StreamReader("data.txt");
Regex all = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)");
string? line;
int sum = 0;
Boolean doo = true;
while ((line = st.ReadLine()) != null)
{
    MatchCollection alll = all.Matches(line);


    foreach (Match match in alll)
    {
        if (match.Value == "don't()")
        {
            doo = false;
        }
        else if (match.Value == "do()")
        {
            doo = true;
        }
        else if (doo && match.Groups.Count == 3)
        {
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);
            sum += x * y;
        }
    }
}
Console.WriteLine(sum);
st.Close();

