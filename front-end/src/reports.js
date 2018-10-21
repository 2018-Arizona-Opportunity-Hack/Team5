import React, { Component } from 'react'
import Chart from './chart'

class Reports extends Component {
  constructor () {
    super()
    this.state = {
      chartData: {}
    }
  }

  componentWillMount () {
    this.getChartData()
  }

  getChartData () {
    // Ajax calls here
    this.setState({
      chartData: {
        labels: ['Phoenix', 'Tucson', 'Scottsdale', 'Mesa', 'Sedona', 'Tempe'],
        datasets: [
          {
            label: '',
            data: [
              617594,
              181045,
              153060,
              106519,
              105162,
              95072
            ],
            backgroundColor: [
              'rgba(255, 99, 132, 0.6)',
              'rgba(54, 162, 235, 0.6)',
              'rgba(255, 206, 86, 0.6)',
              'rgba(75, 192, 192, 0.6)',
              'rgba(153, 102, 255, 0.6)',
              'rgba(255, 159, 64, 0.6)',
              'rgba(255, 99, 132, 0.6)'
            ]
          }
        ]
      }
    })
  }

  render () {
    return (
      <div>
        <Chart chartData={this.state.chartData} location=' Arizona' legendPosition='bottom' />
      </div>
    )
  }
}

export default Reports
