using System.Collections.Generic;
using System.Text;
using System;

class Expression_Helper
{
    static public void init()
    {
        functionHeaders = new List<string> {
                "asin",
                "acos",
                "atan",
                "sin",
                "cos",
                "tan",
                "hyp",
                "log10",
                "ln",
                "sqrt"
           };
    }
    static public List<string> functionHeaders;
    static public void forwardReplacePattern(string input, string patternToReplace, string tobeReplaced)
    {
        StringBuilder result = new StringBuilder(input);
        for (int i = 0; i < input.Length; i++)
        {
            if (checkThereIsAPatternStartHere(input, i, patternToReplace))
            {
                result.Replace(patternToReplace, tobeReplaced);
            }
        }
    }
    static public bool checkThereIsAPatternStartHere(string input, int pos, string pattern)
    {
        if (pos + pattern.Length > input.Length)
        {
            return false;
        }
        for (int i = 0; i < pattern.Length; i++)
        {
            if (input[i + pos] != pattern[i])
            {
                return false;
            }
        }
        return true;
    }
    static public bool checkThereIsAPatternEndHere(string input, int pos, string pattern)
    {
        if (pos - (int)pattern.Length + 1 < 0)
        {
            return false;
        }
        if (!checkThereIsAPatternStartHere(input, pos - (int)pattern.Length + 1, pattern))
        {
            return false;
        }
        return true;
    }


    static public string getFunctionHeader(string input)
    {
        if (input.Length == 0)
        {
            return "NONE";
        }
        foreach (string content in functionHeaders)
        {
            if (checkThereIsAPatternStartHere(input, 0, content))
            {
                if (!checkValidBracket(input.Substring(content.Length + 1, input.Length - content.Length - 2)))
                {
                    continue;
                }
                return content;
            }
        }
        return "NONE";
    }
    static public double applyFunction(double input, string functionHeader)
    {
        if (functionHeader == "sin") return Math.Sin(input);
        else if (functionHeader == "cos") return Math.Cos(input);
        else if (functionHeader == "tan") return Math.Tan(input);
        else if (functionHeader == "hyp") return (input);
        else if (functionHeader == "log10") return Math.Log10(input);
        else if (functionHeader == "ln") return Math.Log(input - 1);
        else if (functionHeader == "sqrt") return Math.Sqrt(input);
        else if (functionHeader == "asin") return Math.Asin(input);
        else if (functionHeader == "acos") return Math.Acos(input);
        else if (functionHeader == "atan") return Math.Atan(input);
        return input;
    }

    static public bool peelOffExtraBracket(ref string input)
    {
        if (input.Length == 0)
        {
            return false;
        }
        if (!(input[0] == '(' && input[input.Length - 1] == ')'))
        {
            return false;
        }
        if (!checkValidBracket(input.Substring(1, input.Length - 2)))
        {
            return false;
        }
        input = input.Substring(1, input.Length - 2);
        return true;
    }

    static public bool isOperator(char c)
    {
        return c == '+' || c == '*' || c == '/' || c == '^';
    }
    static public bool isNumber(string input)
    {
        bool isNumber = double.TryParse(input, out double number);
        return isNumber;
    }
    static public bool checkValidBracket(string input)
    {
        int valid = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                valid++;
            }
            else if (input[i] == ')')
            {
                valid--;
                if (valid < 0)
                {
                    return false;
                }
            }
        }
        return valid == 0;
    }
};
//Node
abstract class BaseNode
{
    public BaseNode left, right;
    public BaseNode()
    {

    }
    public abstract double computeResult(Dictionary<char, double> variablePair);


};
class NumberNode : BaseNode
{
    public NumberNode(double val = 0)
    {
        data = val;
    }
    override public double computeResult(Dictionary<char, double> variablePair)
    {
        return data;
    }
    double data;
};
class VariableNode : BaseNode
{
    public VariableNode(char c = 'x')
    {
        variable = c;
    }
    override public double computeResult(Dictionary<char, double> variablePair)
    {
        if (variablePair.ContainsKey(variable))
        {
            return variablePair[variable];
        }
        //log error
        return -1;
    }
    char variable;
};
class FunctionNode : BaseNode
{
    public FunctionNode(string header = "NONE")
    {
        functionHeader = header;
    }
    override public double computeResult(Dictionary<char, double> variablePair)
    {
        return Expression_Helper.applyFunction(left.computeResult(variablePair), functionHeader);
    }
    string functionHeader;
};
class OperatorNode : BaseNode
{
    public OperatorNode(char c = 'a')
    {
        oper = c;
    }
    override public double computeResult(Dictionary<char, double> variablePair)
    {
        if (oper == '+')
        {
            return left.computeResult(variablePair) + right.computeResult(variablePair);
        }
        if (oper == '-')
        {
            return left.computeResult(variablePair) - right.computeResult(variablePair);
        }
        if (oper == '*')
        {
            return left.computeResult(variablePair) * right.computeResult(variablePair);
        }
        if (oper == '/')
        {
            return left.computeResult(variablePair) / right.computeResult(variablePair);
        }
        if (oper == '^')
        {
            return Math.Pow(left.computeResult(variablePair), right.computeResult(variablePair));
        }
        //error log
        return -1;
    }
    char oper;
};
class Expression_BinaryTree
{
    public Expression_BinaryTree()
    {
        root = null;
    }
    public void buildTreeFromExpression(string s, Dictionary<char, double> variablePair)
    {
        buildTreeFromExpression_Helper(ref root, s, variablePair);
    }
    public double computeResult(Dictionary<char, double> variablePair)
    {
        return root.computeResult(variablePair);
    }

    public bool isEmpty()
    {
        return root == null;
    }
    public void buildTreeFromExpression_Helper(ref BaseNode root, string s, Dictionary<char, double> variablePairs)
    {
        //Console.WriteLine(s);
        while (Expression_Helper.peelOffExtraBracket(ref s)) { }

        if (Expression_Helper.isNumber(s))
        {
            root = new NumberNode(double.Parse(s));
            return;
        }
        if (s.Length == 1)
        {
            foreach (KeyValuePair<char, double> keyValuePair in variablePairs)
            {
                if (s[0] == keyValuePair.Key)
                {
                    root = new VariableNode(s[0]);
                    return;
                }
            }
        }

        //check for function header
        string header = Expression_Helper.getFunctionHeader(s);
        if (header != "NONE")
        {
            root = new FunctionNode(header);
            s = s.Substring(header.Length, s.Length - header.Length);
            while (Expression_Helper.peelOffExtraBracket(ref s)) { }
            buildTreeFromExpression_Helper(ref root.left, s, variablePairs);
            return;
        }

        int i = 0;
        int outOfExpression = 0;

        while (i < s.Length)
        {
            if (s[i] == '+')
            {
                if (outOfExpression == 0)
                {
                    break;
                }
            }
            if (s[i] == '(')
            {
                outOfExpression++;
            }
            else if (s[i] == ')')
            {
                outOfExpression--;
            }
            i++;
        }

        if (i != s.Length)
        {
            root = new OperatorNode(s[i]);
            if (i == 0)
            {
                root.left = new NumberNode(0);
            }
            else
            {
                buildTreeFromExpression_Helper(ref root.left, s.Substring(0, i), variablePairs);
            }

            buildTreeFromExpression_Helper(ref root.right, s.Substring(i + 1, s.Length - (i + 1)), variablePairs);
            return;
        }
        i = 0;
        outOfExpression = 0;
        while (i < s.Length)
        {
            if (s[i] == '*' || s[i] == '/' || s[i] == '^')
            {
                if (outOfExpression == 0)
                {
                    break;
                }
            }
            if (s[i] == '(')
            {
                outOfExpression++;
            }
            else if (s[i] == ')')
            {
                outOfExpression--;
            }
            i++;
        }
        root = new OperatorNode(s[i]);
        buildTreeFromExpression_Helper(ref root.left, s.Substring(0, i), variablePairs);
        buildTreeFromExpression_Helper(ref root.right, s.Substring(i + 1, s.Length - (i + 1)), variablePairs);
    }

    private BaseNode root;
};

//Expression
class Expression
{
    public Expression()
    {
        convertingRules = new Dictionary<string, string>();
        variablePairs = new Dictionary<char, double>();
        eB = new Expression_BinaryTree();
        convertingRules.Add("e", "2.7182818");
        convertingRules.Add("pi", "3.1415");
        convertingRules.Add("-", "+(-1)*");
    }
    //built-in function supported

    //pre-process
    public void preProcess()
    {
        foreach (KeyValuePair<string, string> convert in convertingRules)
        {
            Expression_Helper.forwardReplacePattern(expression, convert.Key, convert.Value);
        }
    }
    public bool checkValidity()
    {
        string temp = expression;
        foreach (KeyValuePair<string, string> convert in convertingRules)
        {
            Expression_Helper.forwardReplacePattern(temp, convert.Key, "+1");
        }
        if (!Expression_Helper.checkValidBracket(temp))
        {
            return false;
        }
        return checkValidity_Helper(temp);
    }

    public void buildComputingTree()
    {
        eB.buildTreeFromExpression(getStringContent(), variablePairs);
    }
    //debug
    //calculate result
    public void makeVariable(char c)
    {
        variablePairs.Add(c, 0);
    }
    public void unMakeVariable(char c)
    {
        variablePairs.Remove(c);
    }
    public void setVariableValue(char c, double value)
    {
        variablePairs[c] = value;
    }
    public double computeResult()
    {
        if (eB.isEmpty())
        {
            //error log
            return -1;
        }
        return eB.computeResult(variablePairs);
    }

    //get, set methods
    public void addConvertingRule(string from, string to)
    {
        convertingRules.Add(from, to);
    }
    public string getStringContent()
    {
        return expression;
    }
    public void setContent(string content)
    {
        expression = content;
    }


    //private
    //friend class Expression_BinaryTree;
    public string expression;
    Expression_BinaryTree eB;

    Dictionary<string, string> convertingRules;
    Dictionary<char, double> variablePairs;

    bool checkValidity_Helper(string input)
    {
        //Console.WriteLine("Checking " + input);
        if (input.Length == 0)
        {
            return false;
        }
        //get rid off extra bracket
        while (Expression_Helper.peelOffExtraBracket(ref input)) ;

        string functionHeader = Expression_Helper.getFunctionHeader(input);
        while (functionHeader != "NONE")
        {
            input = input.Remove(0, functionHeader.Length);
            Expression_Helper.peelOffExtraBracket(ref input);
            functionHeader = Expression_Helper.getFunctionHeader(input);
        }
        while (Expression_Helper.peelOffExtraBracket(ref input)) ;

        //2 cases: 2 operands with an operator or an operand that is a number
        int i = 0;
        int outOfExpression = 0;

        while (i < input.Length)
        {
            if (Expression_Helper.isOperator(input[i]))
            {
                if (outOfExpression == 0)
                {
                    break;
                }
            }
            if (input[i] == '(')
            {
                outOfExpression++;
            }
            else if (input[i] == ')')
            {
                outOfExpression--;
            }
            i++;
        }
        //check for first case
        if (i == 0)
        {
            if (input[i] == '+')
            {
                return checkValidity_Helper(input.Substring(1, input.Length - 1));
            }
            else
            {
                return false;
            }
        }
        if (i < input.Length)
        {
            //cout<<input<<endl;
            return checkValidity_Helper(input.Substring(0, i)) && checkValidity_Helper(input.Substring(i + 1, input.Length - i - 1));
        }
        //check for second case
        return Expression_Helper.isNumber(input);
    }
}