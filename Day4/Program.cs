using StreamReader st = new StreamReader("./data.txt");
string? line;
string[][] arr = new string[300][];
int n = 0;
int m = 0;
int i = 0;
int sum = 0;

void Check(int i, int j)
{
    // horizontal
    if (j + 3 < m)
    {
        if (arr[i][j + 1] == "M" && arr[i][j + 2] == "A" && arr[i][j + 3] == "S") sum++;
    }
    // Reverse horizontal 
    if (j - 3 >= 0)
    {
        if (arr[i][j - 1] == "M" && arr[i][j - 2] == "A" && arr[i][j - 3] == "S") sum++;
    }


    // vertical 
    if (i + 3 < n)
    {
        if (arr[i + 1][j] == "M" && arr[i + 2][j] == "A" && arr[i + 3][j] == "S") sum++;
    }
    // Reverse vertical 
    if (i - 3 >= 0)
    {
        if (arr[i - 1][j] == "M" && arr[i - 2][j] == "A" && arr[i - 3][j] == "S") sum++;
    }

    // diagnol UP
    if (i - 3 >= 0)
    {
        // diagnol UP LEFT
        if (j - 3 >= 0)
        {
            if (arr[i - 1][j - 1] == "M" && arr[i - 2][j - 2] == "A" && arr[i - 3][j - 3] == "S") sum++;
        }
        // diagnol UP RIGHT
        if (j + 3 < m)
        {
            if (arr[i - 1][j + 1] == "M" && arr[i - 2][j + 2] == "A" && arr[i - 3][j + 3] == "S") sum++;
        }
    }


    // diagnol DOWN
    if (i + 3 < n)
    {
        // diagnol DOWN LEFT
        if (j - 3 >= 0)
        {
            if (arr[i + 1][j - 1] == "M" && arr[i + 2][j - 2] == "A" && arr[i + 3][j - 3] == "S") sum++;
        }
        // diagnol DOWN RIGHT
        if (j + 3 < m)
        {
            if (arr[i + 1][j + 1] == "M" && arr[i + 2][j + 2] == "A" && arr[i + 3][j + 3] == "S") sum++;
        }
    }
}

void Check2(int i, int j)
{
    if (i - 1 >= 0 && i + 1 < n && j - 1 >= 0 && j + 1 < m)
    {
        if (arr[i + 1][j + 1] == "M" && arr[i - 1][j + 1] == "M" && arr[i + 1][j - 1] == "S" && arr[i - 1][j - 1] == "S") sum++;
        else if (arr[i - 1][j + 1] == "M" && arr[i - 1][j - 1] == "M" && arr[i + 1][j - 1] == "S" && arr[i + 1][j + 1] == "S") sum++;
        else if (arr[i - 1][j - 1] == "M" && arr[i + 1][j - 1] == "M" && arr[i + 1][j + 1] == "S" && arr[i - 1][j + 1] == "S") sum++;
        else if (arr[i + 1][j + 1] == "M" && arr[i + 1][j - 1] == "M" && arr[i - 1][j - 1] == "S" && arr[i - 1][j + 1] == "S") sum++;
    }
}

while ((line = st.ReadLine()) != null)
{
    arr[i] = line.ToCharArray().Select(c => c.ToString()).ToArray();
    i++;
    n++;
}

for (int k = 0; k < n; k++)
{
    m = arr[k].Length;
    for (int f = 0; f < m; f++)
    {
        if (arr[k][f] == "A") Check2(k, f);
    }
}

Console.WriteLine($"score: {sum}");
