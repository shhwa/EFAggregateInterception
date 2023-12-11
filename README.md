# EFAggregateInterception

This is an example of an efcore interceptor that allows a domain focussed engineer to write thier domain aggregates with no concern for persistable structure, except for an explicit call to GetState().

This should allow domain implementors to vary an object graph however they wish while only being concerned for persistability in so far as it must be possible to implement the GetState() method.