# PizzaRecordConvertor
Visual Studio Application to convert erattically formatted files into format consumable by database import tools

Record Conversion Tool:

Usage Notes: 

User has the option of placing executable in location to be scanned, or manually selecting the scan location upon run.

Expected input: 

One or more text files, named as follows:

order_MMDDYYYY_HHMISS.txt

MM - 2 digit month
DD - 2 digit day
YYYY - 4 digit year
HH - 24 hour 2 digit hour
MI - 2 digit minutes past hour
SS - 2 digit seconds past minute

Intended output:

CustomerData.txt - a text file containing the unique names and personal information of all customers in the collection of order text files
OrderData.txt - a text file containing the order customer and pricing information extracted from the collection of order text files
OrderItemData.txt - a text file containing individual item order data with respect to a given order as extracted from the collection of order text files
MenuItemData.txt - a text file containing unique menu item data, extracted from the collection of order text files



!!!WARNING - READ BEFORE USAGE!!!

This program has been custom designed to extract data from a specifically formatted set of documents, and output that data to a set of documents with their own specific formats. The program has been further designed to, during any given run, recognize duplicate primary data within the set of documents, and filter that data when writing to files requiring unique data values. 

HOWEVER

This logic only applies to the data input during any given run. It does NOT apply to data existing in extant output files. Put simply: if a customer exists twice or more in the order text files, the program will only write the customer to the customer output file once, but the program will NOT check to see if the customer already exists in the customer output file before writing the customer to it. 

The program is, at it's core, a "stupid" converter, and only extracts data from the order text files to output them to files which are suitable for consumption by various import/export tools and scripts used by popular SQL databases. Further methods to ensure the integrity and uniqueness of data should be enacted in the import/export tool being used to import the output files of this program into a given SQL database.
