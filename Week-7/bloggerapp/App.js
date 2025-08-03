import React from 'react';
import './App.css';
import BookDetails from './BookDetails';
import BlogDetails from './BlogDetails';
import CourseDetails from './CourseDetails';

function App() {
  const books = [
    { id: 101, bname: 'Master React', price: 670 },
    { id: 102, bname: 'Deep Dive into Angular 11', price: 800 },
    { id: 103, bname: 'Mongo Essentials', price: 450 },
  ];

  const blogs = [
    {
      title: 'React Learning',
      author: 'Stephen Biz',
      content: 'Welcome to learning React!',
    },
    {
      title: 'Installation',
      author: 'Schewzdenier',
      content: 'You can install React from npm.',
    },
  ];

  const courses = [
    { name: 'Angular', date: '4/5/2021' },
    { name: 'React', date: '6/3/20201' },
  ];

  return (
    <div className="main-container">
      <CourseDetails courses={courses} />
      <BookDetails books={books} />
      <BlogDetails blogs={blogs} />
    </div>
  );
}

export default App;
