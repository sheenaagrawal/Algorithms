public class Solution {
    public bool IsValid(string s) {
        var charArr = s.ToCharArray();
        var stack = new Stack<char>();
        foreach(var member in charArr)
        {
            if(member == '(' ||member == '{' ||member == '[' )
            {
                stack.Push(member);
            }
            
            else if( stack.Count == 0 || member == ')' && stack.Peek() != '(' ||
              member == '}' && stack.Peek() != '{' ||
               member == ']' && stack.Peek() != '[')
            {
                return false;
            }
            else
            {
                stack.Pop();
            }
        }
        if(stack.Count != 0)
        {
            return false;
        }
        return true;
    }
}
