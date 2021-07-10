const http = require('http');

//	Add or remove characters to 'alphabet' in the same way as shown.

//	Any characters not in alphabet will be ignored when encrypting.

alphabet = new Array('A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','1','2','3','4','5','6','7','8','9','0','(',')','~','!','@','#','$','%','^','&','*','-','=','+','_','.',',','`','{','}','[',']','|','\'','\\','\"','/','?',':',';','>','<',' ','\r','\n');



//	Temporary array for when producing binary numbers. Longer length = better encryption.

//	Note:	the max binary number must be more than the alphabet length.

//		there must be an 'a' at the end of the array.

tempbin = new Array("0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","a");



//	Binary numbers stored here and refer to original alphabet.

binary = new Array();



//	Variables for the jumbled(encrypted) alphabet, decrypted text, and encrypted text.

encalphabet = "";

decrypted = "";

encrypted = "";



//	function to make the binary numbers

//	l = current position

//	len = binary number length

//	z = current number

//	The rest is straight forward - figure it out for your self.

function makebinary(l,start,z) {

	if (l < 0)

		return;

	if (tempbin[l] == "1") {

		tempbin[l] = "0";

		x = makebinary(l-1,start,z);

	}else if (tempbin[l] == "0"){

		tempbin[l] = "1";

	}else if (tempbin[l] == "a"){

		tempbin[l] = "0";

	}



	if (l == start) {

		binary[z] = "";

		for (i = 0; i <= l; i++)

			binary[z] += tempbin[i];

	}

	return;

}



//	Calls makebinary() to make enough numbers for all of alphabet.

for (z = 0; z < alphabet.length; z++) {

	makebinary(tempbin.length-1,tempbin.length-1,z);

}


//	Checks to see if a letter (alphabet[x]) is in encalphabet so there are no duplicates in encalphabet.

function in_encalphabet(x) {

	if (x == -1)

		return 0;



	z = alphabet[x];



	for (i = 0; i < encalphabet.length; i++) {

		if (z == encalphabet.substr(i,1))

			return 0;

	}

	return 1;

}



//	Encrypt function (well duh!!)

function encrypt(decrypted) {



//	Set start values

	encalphabet = "";

	encrypted = "";



//	Make encalphabet (ie. jumble alphabet)

	for (i = 0; i < alphabet.length; i++) {

		x = -1;

		while (in_encalphabet(x) == 0)

			x = Math.floor(alphabet.length*Math.random());

	

		encalphabet += alphabet[x];

	}



	temp = encalphabet;



//	First level of encryption.

//	Uses encalphabet's order to jumble text.

	for (i = 0; i < decrypted.length; i++) {

		for (z = 0; z < encalphabet.length; z++) {

			if (decrypted.substr(i,1) == alphabet[z]) {

				temp += encalphabet.substr(z,1);

				break;

			}

		}

	}



//	Second level of encryption.

//	Sets everything into binary.

	for (i = 0; i < temp.length; i++) {

		for (z = 0; z < alphabet.length; z++) {

			if (temp.substr(i,1) == alphabet[z]) {

				encrypted += binary[z];

				break;

			}

		}

	}
	return encrypted;
}



//	This is obviously the decryption function.

function decrypt(encrypted) {



//	Set initial values.

	encalphabet = "";

	temp = "";

	decrypted = "";



//	Go from binary to first level encryption (ie. Still jumbled).

	for (i = 0; i < encrypted.length; i+=tempbin.length) {

		for (z = 0; z < alphabet.length; z++) {

			if (encrypted.substr(i,tempbin.length) == binary[z]) {

				temp += alphabet[z];

				break;

			}

		}

	}



//	Set the order of the alphabet (into encalphabet) from jumbled text.

	for (i = 0; i < alphabet.length; i++)

		encalphabet += temp.substr(i,1);



//	Unjumble the text.

	while (i < encrypted.length) {

		for (z = 0; z < encalphabet.length; z++) {

			if (temp.substr(i,1) == encalphabet.substr(z,1)) {

				decrypted += alphabet[z];

				break;

			}

		}

		i++;

	}
	return decrypted;
}

http.createServer(function (req, res) {
	helpMsg = "Valid endpoints:\r\nPOST /encrypt\r\nPOST /decrypt\r\nRequest body for both should be in plain text.";
	textIn = '';
	req.on("data", (chunk) => {
		textIn += chunk;
	});
	req.on("end", () => {
		//console.log(req.url);
		if (req.method == "POST" && req.headers['content-type'] == "text/plain")
		{
			if (req.url == "/encrypt")
			{
				res.writeHead(200, {'Accept': 'text/plain'});
				res.write(encrypt(textIn));
				res.end();
			}
			else if (req.url == "/decrypt")
			{
				res.writeHead(200, {'Accept': 'text/plain'});
				res.write(decrypt(textIn));
				res.end();
			}
			else
			{
				res.writeHead(404, {'Content-Type': 'text/plain'});
				res.write(helpMsg);
				res.end();
				
			}
		}
		else if (req.headers['content-type'] != "text/plain")
		{
			res.writeHead(415, {'Content-Type': 'text/plain'});
			res.write(helpMsg);
			res.end();
		}
		else
		{
			res.writeHead(405, {'Content-Type': 'text/plain'});
			res.write(helpMsg);
			res.end();
		}
	});
}).listen(9843);

//Original code --- © Matthew Tong 2002
//Adapted to NodeJS @ Robert Setter 2021
