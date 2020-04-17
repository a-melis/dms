import React, {Component} from 'react';
import './App.css';
import axios from 'axios';
import {Header,List} from 'semantic-ui-react';

class App extends Component {
  state = {
    clients: []
  }

  componentDidMount(){
    axios.get("http://localhost:5001/api/clients").then( response => {
       this.setState( this.state.clients = response.data );
      })
  }

  render(){
    return (
      <div>
      <Header as='h2' icon='users' content='DMS' />
        <List>
          {this.state.clients.map((client: any) => (
               <List.Item key={ client.id }> { client.firstName }  { client.lastName }</List.Item>
          ))}
        </List>
    </div> 
    )
  }
}

export default App;
