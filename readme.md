# Export order minion plugin

This is an example of how to create a minion in Sitecore Commerce Engine.

It touches on a number of key concepts in Sitecore Commerce.

What is a minion? Like real minions they are used to perform tasks. They run asynchronous and can be scheduled or can be started manually. Unlike real minions, they don't require user interaction.


Sitecore Commerce Engine comes with a number of default Minions:

* Pending orders minion
* Released orders minion
* Waiting for availability minion
* Settle Sales activity minion
* Refund RMAs minion

As you can see, all these minions work on orders and lists. Lists are used in Sitecore Commerce Engine to organize entities, either depending on states or on a task that needs to be performed on them.  
The pending orders minion takes orders in the _PendingOrders_ list, does some checking and moves them to the _ReleasedOrders_ lists. The released orders minion takes the orders from the _ReleasedOrders_ list and moves them to the _CompletedOrders_ list. 

Most minions have a pipeline associated with them. For instance, the `PendingOrdersMinion` runs the `PendingOrdersMinionPipeline`. Instead of creating your own minion, you can also extend an existing minion by creating a new `Block` and add it to an existing pipeline. 
 
## Creating your own minion

For this sample we are creating a completely new minion that will export the orders that are in the _CompletedOrders_ list to a _json_ file on disk. You can imagine more complex scenario's of course where the order is exported to an ERP ([Ian has an excellent post on this subject](https://websterian.com/2017/06/08/sitecore-commerce-erp-integration-an-approach-part-1-integrating-orders-and-customers/ "Sitecore Commerce ERP integration, an approach – Part 1 – Integrating orders and customers")).

We'll do the following:

* Create a new `ExportOrderMinion;
* 


