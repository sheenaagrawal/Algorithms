public class Solution {
    public int LengthOfLastWord(string s) {
        var subArray = s.Trim().Split(' ');
        var count = subArray.Count();
        return subArray[count-1].ToCharArray().Count();
    }
}
