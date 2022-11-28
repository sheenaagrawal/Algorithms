public class Solution {
    public int Reverse(int x) {
        long count =0;
        
        while(x!=0)
        {
            var rem = x%10;
            count = count*10+rem;
            x=x/10;
        }
        if(count< (long)Int32.MinValue || count > (long)Int32.MaxValue)
        {
            return 0;
        }
        return (int)count;
    }
}
