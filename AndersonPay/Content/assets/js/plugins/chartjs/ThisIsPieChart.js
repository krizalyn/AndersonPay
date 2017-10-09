var ctx = document.getElementById("PieChart").getContext('2d');
var myChart = new Chart(ctx, {
    type: 'pie',
    data: {
        labels: ["2012", "2013", "2014", "2015", "2016", "2017", "2018"],
        datasets: [{
            backgroundColor: [
              "#2ecc71",
              "#3498db",
              "#95a5a6",
              "#9b59b6",
              "#f1c40f",
              "#e74c3c",
              "#34495e"
            ],
            data: [482000, 450300, 399020, 273283, 564922, 400000, 656500]
        }]
    },
    options: {
        title: {
            display: true,
            fontsize: 40,
            text:'Invoice Sale'
        },
        legend: {
            display: true,
            position: "bottom"
        }
    }
});