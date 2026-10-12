const API_URL =
"http://localhost:5284/api/parking";


let records=[];



async function parkVehicle(){


let vehicleNumber =
document
.getElementById("vehicleNumber")
.value.trim();



let vehicleType =
document
.getElementById("vehicleType")
.value;



let message =
document.getElementById("message");



if(vehicleNumber==="" || vehicleType===""){


message.innerText =
"Please enter vehicle details";


return;

}



try{


let response =
await fetch(API_URL,{

method:"POST",

headers:{

"Content-Type":
"application/json"

},


body:JSON.stringify({

vehicleNumber:vehicleNumber,

vehicleType:vehicleType

})


});



if(response.ok){


message.innerText =
"Vehicle parked successfully 🚗";


loadRecords();


clearForm();


}


}

catch(error){


message.innerText =
"Backend not reachable";


console.log(error);


}



}





async function loadRecords(){


try{


let response =
await fetch(API_URL);


records =
await response.json();



displayRecords(records);


updateDashboard();



}

catch(error){


console.log(error);


}


}






function displayRecords(data){


let table =
document.getElementById(
"parkingTable"
);



table.innerHTML="";



data.forEach(item=>{


table.innerHTML += `

<tr>

<td>${item.id}</td>

<td>${item.vehicleNumber}</td>

<td>${item.vehicleType}</td>

<td>
${new Date(item.entryTime)
.toLocaleString()}
</td>


<td>

<span class="status">

${item.status}

</span>


</td>


</tr>

`;


});


}







function updateDashboard(){


let total=20;


let occupied=
records.length;


document.getElementById(
"totalSlots"
).innerText=total;



document.getElementById(
"occupiedSlots"
).innerText=occupied;



document.getElementById(
"availableSlots"
).innerText=
total-occupied;


}







function searchVehicle(){


let value =
document
.getElementById("search")
.value
.toLowerCase();



let filtered =
records.filter(x=>


x.vehicleNumber
.toLowerCase()
.includes(value)


);



displayRecords(filtered);



}







function clearForm(){


document.getElementById(
"vehicleNumber"
).value="";


document.getElementById(
"vehicleType"
).value="";


}




document.addEventListener(
"DOMContentLoaded",
loadRecords
);