# Networks-and-Online-Games Lab Session2: TCP-UDP

To make this exercise we have used an approach based on creating 2 scenes in the project: Server and Client. 

We will manage both types of protocols(UDP/TCP) via a third scene called Menu, 
by selecting the protocol we want from the menu scene we can choose between them and load and activate the selected protocols.

To test the server-client connection you will need to duplicate the project (make a copy or many copies).

To test the UDP server-client connection you will need 2 copies of the project connection playing the UDP Server in one, and the UDP Client in the other. 
The Server needs to be initialized first.

To test the TCP server-client connection you will need 2 copies or more. 
To select how many clients will be in the backlog of the TCP connection (default to 2) 
the variable in the "TCPServer" script inspector in the TCP Server scene can be modified to the number of copies of the project that will be tested. 
This way, if the server is connected and different clients try to connect simultaneously
the program will make them queue until the previous has finished communicating.

The ping, pong messages are displayed in both console and UI (TextBubble).
