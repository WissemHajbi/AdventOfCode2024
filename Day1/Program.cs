using StreamReader st = new("./data.txt");
string nigger = st.ReadToEnd();
string[] niggers = nigger.Split("\n");
List<int> numbers1 = new List<int>();
List<int> numbers2 = new List<int>();
foreach ( string nig in niggers){
	string[] a = nig.Split("   ",StringSplitOptions.RemoveEmptyEntries);
	if (a.Length >= 2) 
            {
                numbers1.Add(int.Parse(a[0])); 
		numbers2.Add(int.Parse(a[1]));
            }
}
numbers1.Sort();
numbers2.Sort();
int sum = 0;
foreach(int num in numbers1) sum += num * numbers2.FindAll(x => x == num).Count; 
Console.WriteLine(sum);
