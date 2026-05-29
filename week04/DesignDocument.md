# Foundation Programs Design Notes

## 1. YouTube Video Program

**What the program does:**
It keeps track of YouTube videos and the comments people leave on them. It stores the video info and prints it all out.

**Classes and Responsibilities:**

*   **Video Class**
    *   Responsibilities: Store the video's details and keep a list of comments. It also needs to calculate how many comments there are.
    *   Variables: 
        *   `_title` (string)
        *   `_author` (string)
        *   `_length` (int - in seconds)
        *   `_comments` (list of Comment objects)
    *   Methods: 
        *   `GetNumberOfComments()` - returns the count of the comments list.

*   **Comment Class**
    *   Responsibilities: Store the details of a single comment.
    *   Variables:
        *   `_name` (string - the person commenting)
        *   `_text` (string - what they said)

**How it runs:**
In the Main program, we'll create 3 or 4 Video objects. For each one, we'll create 3 or 4 Comment objects and add them to the video's list. Then we'll put all the videos in a big list and loop through it to print out the title, author, length, total number of comments, and then loop through and print all the actual comments.

---

## 2. Online Ordering Program

**What the program does:**
It tracks customer orders for an online store, calculates total prices (including shipping), and prints out packing and shipping labels.

**Classes and Responsibilities:**

*   **Product Class**
    *   Responsibilities: Store info about a specific product being bought and figure out its total cost based on quantity.
    *   Variables: `_name` (string), `_productId` (string), `_price` (double), `_quantity` (int)
    *   Methods: `GetTotalCost()` - multiplies price by quantity. Also needs getters for name and id.

*   **Address Class**
    *   Responsibilities: Store the parts of a physical address and figure out if it's in the USA.
    *   Variables: `_streetAddress` (string), `_city` (string), `_stateProvince` (string), `_country` (string)
    *   Methods: 
        *   `IsInUSA()` - returns true or false based on the country.
        *   `GetFullAddress()` - returns all the variables combined into one formatted string.

*   **Customer Class**
    *   Responsibilities: Store the customer's name and their address object.
    *   Variables: `_name` (string), `_address` (Address object)
    *   Methods: `IsInUSA()` - just calls the address's IsInUSA method. Getters for name and address.

*   **Order Class**
    *   Responsibilities: Store a list of products and the customer making the order. Calculate the final price and make the labels.
    *   Variables: `_products` (list of Product objects), `_customer` (Customer object)
    *   Methods: 
        *   `GetTotalCost()` - adds up all product costs, then adds $5 if the customer is in the USA, or $35 if not.
        *   `GetPackingLabel()` - returns a string with the name and ID of each product.
        *   `GetShippingLabel()` - returns a string with the customer's name and full address.

**How it runs:**
In the Main program, we'll create a couple of Address objects and use them to create Customer objects. Then we'll create an Order for each customer. We'll create a few Product objects and add them to the orders. Finally, we'll print out the packing label, shipping label, and the total cost for each order by calling the Order methods.
