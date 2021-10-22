# Networks-and-Online-Games Lab Session2: TCP-UDP

To make this exercise we have used an approach based on creating 2 scenes in the project: Server and Client. We will manage both types of protocols(UDP/TCP) via a third scene called Menu, by selecting the protocol we want from 
the menu scene we can choose between them and load and activate the selected protocols. 
To test the UDP server-client connection you will need to duplicate the project connection playing the UDP Server in one project and the UDP Client in another. The Server needs to be initialized first.
To test the TCP server-client connection you will need to select how many clients will be in the backlog of the TCP connection by changing the variable in the script inspector in the TCP Server scene. Once that is done, the user
will need to duplicate the project the number of times equal to the number of client backlogs, to act as a client in the UDP Client scene. This way, if the server is connected and different clients try to connect simultaneously
the program will make them queue until the previous has finished communicating.
