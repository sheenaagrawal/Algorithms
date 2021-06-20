public class Solution {
    public int RomanToInt(string s) {
        var map = new Dictionary<char,int>(){{'I',1},{'V',5},{'X',10},{'L',50},{'C',100},{'D',500},{'M',1000}};
        var charArr = s.ToCharArray();
        var result =0;
        for(int i=0;i<charArr.Length; i++)
        {
            if(i!=0 && (charArr[i] == 'V'|| charArr[i] == 'X') && charArr[i-1] == 'I')
            {
                result += map[charArr[i]]-2;
            }
            else if(i!=0 && (charArr[i] == 'L'|| charArr[i] == 'C') && charArr[i-1] == 'X')
            {
                result += map[charArr[i]]-20;
            }
            else if(i!=0 && (charArr[i] == 'D'|| charArr[i] == 'M') && charArr[i-1] == 'C')
            {
                result += map[charArr[i]]-200;
            }
            else result+=map[charArr[i]];
        }
        return result;
    }
}
