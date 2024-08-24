using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

IEnumerable<char> PreProcess(string input)
{
    foreach (char c in input)
    {
        if("{[()]}".Contains(c))
            yield return c;
    }
}

bool IsBalanced(string input)
{
    var symbols = new Dictionary<char, char>()
    {
        {'}', '{'},
        {']','['},
        {')','('}
    };

    var stack = new Stack<char>();
    foreach (char c in PreProcess(input))
    {
        if (symbols.ContainsValue(c))
            stack.Push(c);
        else if (symbols.ContainsKey(c) && stack.Count > 0)
        {
            if (symbols[c] != stack.Pop())
                return false;
        }
        else return false;
    }
    return stack.Count == 0;
}

Console.WriteLine(IsBalanced("(jhgfhsgf{())})"));

return;


var dictionary = new Dictionary<string, string>()
{
    {"{","}"},
    {"[","]"},
    {"(",")"}
};
// if count was un even program crashed [Fixed]
// Use of )) nets Balanced while (( nets not balanced  [x]
/// HAPB("(el (queso) es delicioso ())") => true
/// HAPB("(comer (engorda)") => false
/// IBE("2 ^ {3 * [2 ^ (1+2)]}") => true
/// IBE("2 ^ {3 * [2 ^ (1+2)}") => false

var Input = ("2 ^ {3 * [2 ^ (1+2)}");
// Remove Alphabet letters ,numbers , Math signs out of Input
string removeAlphabet = Regex.Replace(Input, "[A-Za-z ]", "");
string removeNumbers_MathSign = new String(removeAlphabet.Where(c => c != '-' && c != '^' && c !='+'&& c !='*' && (c < '0' || c > '9')).ToArray());
var Result = removeNumbers_MathSign;


// Input cannot run out of space  -  capacity increases by need.
var queue = new Queue();
var stack = new Stack();

bool isBalanced = true;
// Size of our Input
var size = Result.ToCharArray().Length;

// Do not really understand this.
if (size % 2 != 0)
{
    isBalanced = false;
}
else
{
    foreach(var c in Result.ToCharArray())
    {
        stack.Push(c.ToString());
        queue.Enqueue(c.ToString());
    }

    while (stack.Count > size / 2 && queue.Count > size / 2)
    {
        var a = (string)queue.Dequeue();
        var b = (string)stack.Pop();

        if(dictionary.ContainsKey(a)&& b != dictionary[a])
        {
            isBalanced = false;
        }
    }
    Console.WriteLine(isBalanced?"Balanced":"Not Balanced");
    Console.ReadLine();
}
