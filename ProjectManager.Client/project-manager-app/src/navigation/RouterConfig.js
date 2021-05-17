import { Route, Switch } from 'react-router-dom';
import App from '../App';
import Profile from '../features/profile';
import ProjectList from '../features/projects';
import Routes from './Routes'


const RouterConfig = () => {
  return (
    <Switch>
      <Route exact path={Routes.HOME} component={App} />
      <Route path={Routes.PROJECTS} component={ProjectList} />
      <Route path={Routes.PROFILE} component={Profile} />
    </Switch>
  )
}

export default RouterConfig