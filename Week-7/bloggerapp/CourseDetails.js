import React from 'react';

const CourseDetails = ({ courses }) => {
  let content;
  if (courses.length === 0) {
    content = <p>No courses found.</p>;
  } else {
    content = (
      <ul>
        {courses.map((course, index) => (
          <div key={index}>
            <h3>{course.name}</h3>
            <h4>{course.date}</h4>
          </div>
        ))}
      </ul>
    );
  }

  return (
    <div className="section">
      <h1>Course Details</h1>
      {content}
    </div>
  );
};

export default CourseDetails;