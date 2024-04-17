#pragma once

#include <opencv2/core.hpp>
#include <array>

namespace FaceLandmarking::FeatureExtraction
{
	static const std::array<cv::Mat, 5> BasicFilters
	{
		cv::Mat{
			+1,
		},
		cv::Mat{
			+1, 0, -1,
			+2, 0, -2,
			+1, 0, -1,
		},
		cv::Mat{
			+1, +2, +1,
			 0,  0,  0,
			-1, -2, -1,
		},
		cv::Mat{
			+1,  0,  0,  0, -1,
			+2, +1,  0, -1, -2,
			+4, +2,  0, -2, -4,
			+2, +1,  0, -1, -2,
			+1,  0,  0,  0, -1,
		},
		cv::Mat{
			+1, +2, +4, +2, +1,
			 0, +1, +2, +1,  0,
			 0,  0,  0,  0,  0,
			 0, -1, -2, -1,  0,
			-1, -2, -4, -2, -1,
		}
	};
}