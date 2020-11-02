import logo from './logo.svg';
import './App.css';
import GetAllSessions from './DAL/GetAllSessions';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import Grid from '@material-ui/core/Grid';

import React, {Component} from "react";



function Home() {
  const classes  = makeStyles((theme) => ({
    root: {
      flexGrow: 1,
    },
    paper: {
      padding: theme.spacing(2),
      textAlign: 'center',
      color: theme.palette.text.secondary,
    },
  }));
  return (
    <Container maxWidth="sm">
    <div className={classes.root}>
        <SessionList/>
    </div>
    </Container>
  );
}

class SessionList extends React.Component{
  constructor(props){
    super(props);
    var sessions = GetAllSessions("http://localhost:3333/api/method/GetSessionData",this.updateState,this);
    
    this.state = {
      sessions: []
    };
  }

  updateState(component,data){
    
    component.setState({sessions: data});
  }
  render(){
    const classes = makeStyles({
      root: {
        minWidth: 275,
      },
      bullet: {
        display: 'inline-block',
        margin: '0 2px',
        transform: 'scale(0.8)',
      },
      title: {
        fontSize: 14,
      },
      pos: {
        marginBottom: 12,
      },
    });
    const listItems = this.state.sessions.map((session) =>
      
      <Grid item xs={3}>
        <Card  className={classes.root} >
          <CardContent>
            <Typography variant="h5" component="h2">
              {session.SessionId}
            </Typography>
            <Typography className={classes.pos} color="textSecondary">
              {session.Date}
            </Typography>
          </CardContent>
          <CardActions>
            <Button size="small" href={"/"+session.SessionId}>View</Button>
          </CardActions>
        </Card>
    </Grid>
    );
    return (
      <Grid container spacing={3}>
        {listItems}
      </Grid>
    );
  }
}
export default Home;
