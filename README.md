# StreamBetting Web Project

a service that allows people to quickly determine what stream they'd like to watch.
and maybe bet on the outcome sometimes. 

##API Listings
##Twitch			: https://dev.twitch.tv/docs [started]
##Azubub 			: http://content.azubu.tv/api/ [started]
(30 second refresh rate)
##Dailymotion			: https://developer.dailymotion.com/api
##Hitbox 			: http://developers.hitbox.tv/
##UStream			: http://developers.ustream.tv/
(Not Free)
##Youtube Gaming		: https://developers.google.com/youtube/v3/live/docs/
##Veetle API			: No URL, Lots of github repo's though 

###Bitcoin Resources		
##General Overview		: https://www.codeproject.com/articles/768412/nbitcoin-the-most-complete-bitcoin-port-part-crypt
##C# Wallet Project		: https://github.com/MetacoSA/NBitcoin			
Others:   
##Steam Broadcasting(https://steamcommunity.com/updates/broadcasting)
It would be interesting to see if one couldn't get the data needed out of memory. Web api dosen't exist


##//todo: 2.1.2017
##i	Determine which api's to use to start building:
		a. service that can consome and parse web data (started twitch is done, we'll need to incorporate more to see if it works) 
		b. determine backend schema for caching channels meta-data (started, will check in by 2.7.2016)
		c. get some data out to the front end to mess around with 
##ii	Create Utility Objects for 
		i.a - Generic Web Interface to interact with web api's
		i.b & i.c - Generic MongoDB Interface for crud operations and storing data 
##iii	Autonomous DataStreaming Jobs - Backend (Needs a server of some sort)
		a. queries apis 
		b. updates backend documents for recent channel data 

		
