Console.WriteLine(sPalindrome("ana"));
int[] array = { 223, 2, 3, 4, 5, 6, 0, 1, -5, -22, -12, -1 };
Console.WriteLine(MinSplit(4000));
Console.WriteLine(NotContains(array));
Console.WriteLine(IsProperly("((()()())(")); ;

//1.დაწერეთ ფუნქცია, რომელსაც გადაეცემა ტექსტი  და აბრუნებს პალინდრომია თუ არა. (პალინდრომი არის ტექსტი რომელიც ერთნაირად იკითხება ორივე მხრიდან). 
static bool sPalindrome(string text)
{
	string reversetext = "";

	for (int i = text.Length - 1; i >= 0; i--)
	{
		reversetext += text[i].ToString();
	}

	if (reversetext == text)
	{
		return true;
	}

	return false;
}

//2.გვაქვს 1,5,10,20 და 50 თეთრიანი მონეტები.დაწერეთ ფუნქცია, რომელსაც გადაეცემა თანხა (თეთრებში) და აბრუნებს მონეტების მინიმალურ რაოდენობას, რომლითაც შეგვიძლია ეს თანხა დავახურდაოთ.

static int MinSplit(int amount)
{
	if (amount % 50 == 0)
	{
		return amount / 50;
	}
	else if (amount % 50 % 20 == 0)
	{
		return amount / 50 + amount % 50 / 20;
	}
	else if (amount % 50 % 20 % 10 == 0)
	{
		return amount / 50 + amount % 50 / 20 + amount % 50 % 20 / 10;
	}
	else if (amount % 50 % 20 % 10 % 5 == 0)
	{
		return amount / 50 + amount % 50 / 20 + amount % 50 % 20 / 10 + amount % 50 % 20 % 10 / 5;
	}
	else if (amount % 50 % 20 % 10 % 5 % 1 == 0)
	{
		return amount / 50 + amount % 50 / 20 + amount % 50 % 20 / 10 + amount % 50 % 20 % 10 / 5 + amount % 50 % 20 % 10 % 5 / 1;
	}

	return 0;
}

//3.მოცემულია მასივი, რომელიც შედგება მთელი რიცხვებისგან. დაწერეთ ფუნქცია რომელსაც გადაეცემა ეს მასივი და აბრუნებს მინიმალურ მთელ რიცხვს, რომელიც 0-ზე მეტია და ამ მასივში არ შედის.
static int NotContains(int[] array)
{
	int smallestint = 1;

	for (int i = 0; i < array.Length - 1; i++)
	{
		for (int j = 0; j < array.Length - 1; j++)
		{
			if (array[j] > array[j + 1])
			{
				(array[j + 1], array[j]) = (array[j], array[j + 1]);
			}
		}
	}

	for (int i = 0; i < array.Length - 1; i++)
	{
		if (array[i] == smallestint)
		{
			smallestint++;
		}
		else if (array[i] > smallestint)
		{
			return smallestint;
		}
	}

	return smallestint;
}

//4.მოცემულია String რომელიც შედგება „(„ და „)“ ელემენტებისგან.დაწერეთ ფუნქცია რომელიც აბრუნებს ფრჩხილები არის თუ არა მათემატიკურად სწორად დასმული.
static bool IsProperly(string sequence)
{
	int count = 0;
	int left = 0;
	int right = 0;
	bool isfirst = true;

	for (int i = 0; i < sequence.Length; i++)
	{
		if (sequence[i] == '(')
		{
			left++;
		}
		else
		{
			right++;
		}
	}

	if (left != right)
	{
		return false;
	}

	for (int i = 0; i < sequence.Length / 2; i++)
	{
		if ((sequence[i] == ')' || sequence[sequence.Length - 1] == '(') && isfirst == true)
		{
			return false;
		}

		isfirst = false;
		count++;

		if (count == sequence.Length / 2)
		{
			return true;
		}
	}

	return false;
}