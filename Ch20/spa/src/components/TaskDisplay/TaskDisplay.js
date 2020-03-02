import React, { Component } from 'react'

export default class TaskDisplay extends Component {
    
    componentDidMount(){
        this.props.onLoad();
    }

    render() {
        return (
            <div>
                {this.props.tasks.map(item => <div key={item.id}>{item.name}</div>)}
            </div>
        )
    }
}