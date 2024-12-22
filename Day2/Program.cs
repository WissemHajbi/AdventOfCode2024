using StreamReader st = new StreamReader("./data.txt");
string line;
int count = 0;
int totalReports = 0;
bool IsSafe(List<int> numbers)
{
    bool asc = numbers[0] < numbers[1];
    for (int i = 0; i < numbers.Count - 1; i++)
    {
        int diff = numbers[i] - numbers[i + 1];
        if ((asc && diff >= 0) || (!asc && diff <= 0) || Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
        {
            return false;
        }
    }
    return true;
}

while ((line = st.ReadLine()) != null)
{
    string[] strings = line.Split(' ');
    List<int> numbers = new List<int>();
    for (int i = 0; i < strings.Length; i++) numbers.Add(int.Parse(strings[i]));

    totalReports++;

    if (IsSafe(numbers))
    {
        count++;
        continue;
    }

    bool canBeMadeSafe = false;
    for (int i = 0; i < numbers.Count; i++)
    {
        List<int> modifiedNumbers = new List<int>(numbers);
        modifiedNumbers.RemoveAt(i);
        if (IsSafe(modifiedNumbers))
        {
            canBeMadeSafe = true;
            break;
        }
    }

    if (canBeMadeSafe)
    {
        count++;
    }
}

Console.WriteLine($"Total safe reports: {count}");
