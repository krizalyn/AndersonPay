var ctx = document.getElementById("BarChart").getContext('2d');
ctx.height = 125;

Chart.defaults.global.defaultFontFamily = "Raleway";
Chart.defaults.global.defaultFontSize = 16;
Chart.defaults.global.defaultFontColor = "Black";
Chart.defaults.global.legend.display = false;
Chart.defaults.global.tooltips.displayColors = false;

var myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ["January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
        datasets: [{
            label: "Invoice Total Sales",
            borderWidth: 1,
            borderColor: 'rgba(20, 20, 20, 0.3)',
            hoverBorderColor: 'rgba(20, 20, 20, 0.8)',
            data: [100000, 125000, 150000, 175000, 200000, 225000, 250000, 275000, 300000, 325000, 350000, 375000],
            backgroundColor: [
                'rgba(255, 99, 132, 0.5)',
                'rgba(54, 162, 235, 0.5)',
                'rgba(255, 206, 86, 0.5)',
                'rgba(75, 192, 192, 0.5)',
                'rgba(153, 102, 255, 0.5)',
                'rgba(255, 159, 64, 0.5)',
                'rgba(255, 99, 132, 0.5)',
                'rgba(54, 162, 235, 0.5)',
                'rgba(255, 206, 86, 0.5)',
                'rgba(75, 192, 192, 0.5)',
                'rgba(153, 102, 255, 0.5)',
                'rgba(255, 159, 64, 0.5)'
            ],
            hoverBackgroundColor: [
                'rgba(255, 99, 132, 0.9)',
                'rgba(54, 162, 235, 0.9)',
                'rgba(255, 206, 86, 0.9)',
                'rgba(75, 192, 192, 0.9)',
                'rgba(153, 102, 255, 0.9)',
                'rgba(255, 159, 64, 0.9)',
                'rgba(255, 99, 132, 0.9)',
                'rgba(54, 162, 235, 0.9)',
                'rgba(255, 206, 86, 0.9)',
                'rgba(75, 192, 192, 0.9)',
                'rgba(153, 102, 255, 0.9)',
                'rgba(255, 159, 64, 0.9)'
            ]
        }]
    },
    options: {
        title: {
            display: true,
            text: "Invoice Sales",
            padding: 10,
            fontSize: 24,
            position: "top"
        },
        scales: {
            yAxes: [{
                gridLines: {
                    show: true,
                    drawTicks: false,
                    color: "rgba(30, 30, 30, 0.4)",
                    zeroLineColor: "rgba(30, 30, 30, 0.4)",
                },
                scaleLabel: {
                    display: true,
                    labelString: 'Total Invoice Sales (2017)'
                },
                ticks: {
                    padding: 10,
                    beginAtZero: true
                }
            }],
            xAxes: [{
                gridLines: {
                    zeroLineColor: "transparent",
                    color: "rgba(0, 0, 0, 0)",
                },
                scaleLabel: {
                    display: true,
                    labelString: 'Months'
                }
            }]
        }
    }
});