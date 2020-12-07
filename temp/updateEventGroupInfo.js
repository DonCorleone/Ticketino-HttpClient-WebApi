db.getCollection('EventGroupInfos').update(
    // query 
    {
        "id" : 3124
    },
    
    // update 
    {
        'id': NumberInt(3124),
        'name': 'De schlaui Igel Pic 44',
        'dateCreated': new Date('2020-11-29T20:09:18.01+01:00')
    }, 
    {
        'upsert':true
    }
 );