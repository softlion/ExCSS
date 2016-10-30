#Softlion's updates from original (2016/09)

- Removed all external references
- Removed all methods which would be slow or make parsing slow if used
- Speed up parsing and decreased memory usage a lot. Note that the css parsing is still a slow operation.

#ExCSS StyleSheet Parser for .NET - It's \#BADA55!#

ExCSS (Pronounced Excess) is a CSS 2.1 and CSS 3 parser for .NET.

The goal of ExCSS is to make it easy to read and parse stylesheets into a friendly object model with full LINQ support.

#Version 2.0#
Version 2 has been rewritten from the ground up!  Unlike v1 which used Coco/r to generate a lexer and parser, version 2 is 
written entirely by hand.  This gives the new parser an incredibly fine grained level of detail when parsing some of the more unusual edge cases for CSS 3 selectors.

#NuGet#
Install the pagckage from the NuGet Package Manager or via command line

	Install-Package ExCSS 

#Lexing and Parsing - How it all Works#
ExCSS uses a Lexer and a Parser based on a CSS3-specific grammar. The Lexer and Parser read CSS text and parse each 
character as individual tokens run against a complex set of rules that define what CSS segment each token represents.  
Once parsed, the input styles sheet is turned into a standard .NET object model. That means it's fully queryable using Linq to objects.

##A basic example:##

	var parser = new Parser();
	var stylesheet = parser.Parse(".someClass{color: red; background-image: url('/images/logo.png')");
	
	var imageUrl = stylesheet.Rulesets
                .SelectMany(r => r.Declarations)
                .FirstOrDefault(d => d.Name.Equals("background-image", StringComparison.InvariantCultureIgnoreCase))
                .Term
                .ToString(); // Finds the url('/images/logo.png') image url
				
##CSS 3 Compatible##
The project has a growing suite of tests.  Currently the tests account for and pass all CSS Level 3 selector definitions
found in [the W3 CSS 3 Release Candidate documentation](http://www.w3.org/TR/2001/CR-css3-selectors-20011113/)



