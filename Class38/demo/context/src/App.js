import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Header from './components/header';
import ClassCounter from './components/class-counter';
import HooksCounter from './components/hooks-counter';
import TodoList from './components/todo-list';
import useTheme from './contexts/theme';

function App() {
  const { mode } = useTheme();

  return (
    <div className={mode}>
      <Header />
      <main>
        <Switch>
          <Route path="/class">
            <ClassCounter initialCount={5} />
          </Route>
          <Route path="/hooks">
            <HooksCounter initialCount={7} />
          </Route>
          <Route path="/todo">
            <TodoList />
          </Route>
        </Switch>
      </main>
    </div>
  );
}

export default App;