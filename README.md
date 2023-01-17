
# NatsPoc
Nats Publisher subscriber poc to test on 


## Pre requesites 
 
Installing nats server using `brew`
`brew install nats-server`
Install the NATS CLI
`brew tap nats-io/nats-tools` 
`brew install nats-io/nats-tools/nats`

To test your installationg, type and run the command
`nats-server -V`
That will start your NATS server on.
On another terminal session first check the connection to the server by running `nats server check`
If it shows OK Connection you are ok to start.
## How to start 
 
Clone this repo and open the sln file at Visual Studio
Run `nats-server` on any terminal to start the server
On Visual Studio, Run the NatsSubscriber and then the NatsPublisher. 

Both will connect to the NATS local server, listen and publish some message.

