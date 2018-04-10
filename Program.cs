using System;

namespace firstproj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Pig_Latin("Hello World"));
            Console.WriteLine(Pig_Latin("Pig latin is cool"));
            int[] array = {5, 3, 2, 8, 1, 4};
            int[] array2 = {6, 3, 2, 7, 5, 0};
            Odd_Qsort(array,0,array.Length-1);
            Odd_Qsort(array2,0,array2.Length-1);
            for(int i = 0; i < array.Length; i++){
                Console.Write(array[i] + " ");
            }
            Console.Write("\n");
            for(int i = 0; i < array2.Length; i++){
                Console.Write(array2[i] + " ");
            }
            Console.Write("\n");
        }


        public static String Pig_Latin(String s){
            string[] words = s.Split(" "); //take the string and tokenize the words
            string[] result = new string[words.Length]; //create a new array that will hold modified words
            
            for(int i = 0; i < words.Length; i++){
                string first = words[i].Substring(0,1); //get the first letter of the word
                result[i] = words[i].Replace(first,""); //delete the first letter and append the word to the new array
                result[i] += first + "ay"; //append the first letter and "ay"
            }
            return String.Join(" ",result); //join the array into a string and return
        }



        public static void Odd_Qsort(int[] array, int l, int r){
            //I went with a quick sort approach
            if(l < r){
                int pivot = Odd_Partition(array, l, r);
                Odd_Qsort(array,l,pivot-1);
                Odd_Qsort(array,pivot+1,r);
            }//end if 
        }//end Odd_Qsort

        public static int Odd_Partition(int[] array, int l, int r){
            //modified the partition function to only sort the odd values
            int pivot  = array[r];
            int i = l-1;
            for(int j = l; j < r; j++ ){
                if(array[j] <= pivot && array[j] % 2 == 1)//swap around only if odd
                {
                    i++;
                    int temp1 = array[i];
                    array[i] = array[j];
                    array[j] = temp1;

                }//end inner if
            }//end for

            if (array[i+1] % 2 == 1 && array[r] % 2 == 1){ //swap last element if it is odd
                int temp = array[i+1];
                array[i+1] = array[r];
                array[r] = temp;
            }
            return i + 1;
        }
    }
}
