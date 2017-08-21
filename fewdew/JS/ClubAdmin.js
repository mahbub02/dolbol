 var xList=new Array();
    var yList=new Array();
    var InsideChecking=false;
        $(document).ready(function(){
        
        $("#club-chatter").click(function(e){
           
                xList[$(xList).length]=e.pageX;
                yList[$(yList).length]=e.pageY;
                $("#club-chatter").html("");   
                $("#club-chatter").drawPolygon(xList, yList, {color:'#00FF00', alpha: .9});
        });
        
        $("#saveTheArea").click(function(){
           alert("");
        var Xs;
            for(var i=0;i<xList.length;i++)
            {
               if(i==0){
                Xs=xList[i];
               }
               else{
                Xs=Xs+","+xList[i];
               }
            }
             var Ys;
            for(var i=0;i<yList.length;i++)
            {
               if(i==0){
                Ys=yList[i];
               }
               else{
                Ys=Ys+","+yList[i];
               }
            }
                         $.ajax({
                                
                                  type: "POST",
                                  url: "club.aspx/SaveClubPlace",
//                                  data: "Xs="+xList, 

                                  data:"{'Xs':'" +Xs + "','Ys':'" +Ys+ "','room_id':'" +$("#hiddenRoomId").val()+ "','linkTo':'" +$("#linkTo").val()+ "'}",
                                  contentType: "application/json; charset=utf-8",
                                  dataType: "json",
                                  success: function(msg) {
                                            
                                  },
                                  error: AjaxFailed
                                });
                });   
       
       
    });
    
     function AjaxFailed(request,status,error) {
        var exp = new RegExp('<title>(.*)<\/title>','i');
        if (exp.exec(request.responseText)) {
           alert( request.responseText );
        }
        else {
           alert( request.responseText );
        }
    }
    function pointInPolygon(x,y) {

        var i;
        var j=$(xList).length-1 ;
        
        var  oddNodes=false;
        
          for (i=0; i<$(xList).length; i++)
          {
                if (yList[i]<y && yList[j]>=y ||  yList[j]<y && yList[i]>=y)
                 {
                  if (xList[i]+(y-yList[i])/(yList[j]-yList[i])*(xList[j]-xList[i])<x)
                   {
                    oddNodes=!oddNodes;
                  
                   }
                 }     
              j=i;
          }
    return oddNodes;
  }