var input = File.ReadAllLines("input.txt");

int x = 1;
int cycle = 0;
var cyclesToSum = new[] { 20, 60, 100, 140, 180, 220 };
var addToXOnCycle = new Dictionary<int, int>();
int sumOfSignalStrengths = 0;

// Uppgift 2 
int crtWidth = 40;
int crtHeight = 6;
char[][] screen = new char[crtHeight][];

for (int i = 0; i < crtHeight; i++)
{
    screen[i] = new char[crtWidth];
    Array.Fill(screen[i], '.');
}

// Loopar igenom för att räkna cykler och skapa dictionary av när vi ska lägga till värden till X
foreach (var row in input)
{
    if (row == "noop")
    {
        cycle++;
    }
    else
    {
        int add = int.Parse(row.Split(' ')[1]);
        addToXOnCycle[cycle + 2] = add;
        cycle += 2;
    }
}

// Loopar igenom alla cykler och kollar om vi ska lägga till i totalen och om vi ska addera till X
for (int i = 1; i <= cycle; i++)
{
    // Vi behöver veta vilken rad/column vår utritade pixel är i då vår sprite bara går horisontellt
    int row = (i - 1) / crtWidth;
    int col = (i - 1) % crtWidth;

    // Kolla om vår sprite (x-1, x, x+1) överlappar med vår nuvarande pixel och rita ut
    if (col >= x - 1 && col <= x + 1)
    {
        screen[row][col] = '#';
    }

    if (cyclesToSum.Contains(i))
    {
        sumOfSignalStrengths += i * x;
    }

    if (addToXOnCycle.TryGetValue(i, out int add))
    {
        x += add;
    }
}

// Uppgift 1
Console.WriteLine(sumOfSignalStrengths);

// Uppgift 2
foreach (var line in screen)
{
    Console.WriteLine(new string(line));
}