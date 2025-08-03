import React from 'react';

const BlogDetails = ({ blogs }) => {
  return (
    <div className="section">
      <h1>Blog Details</h1>
      {blogs.length > 0 &&
        blogs.map((blog, index) => (
          <div key={index}>
            <h2>{blog.title}</h2>
            <h4>{blog.author}</h4>
            <p>{blog.content}</p>
          </div>
        ))}
    </div>
  );
};

export default BlogDetails;