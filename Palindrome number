public class Solution {
    public bool IsPalindrome(int x) {
        long temp = x;
        long rev =0;
        if(x<0)
        {
            return false;
        }
        while(x!=0)
        {
            var rem = x%10;
            rev = rev*10+rem;
            x=x/10;
        }
        return temp==rev?true:false;
    }
}
